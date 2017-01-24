/*
 * Модуль обновления приложения Garant Checker Offline.
 * 
 * Copyright 2012 - 2017 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2017 EasyCoding Team.
 * 
 * Лицензия кода: модифицированная лицензия BSD.
 * Лицензия контента: Creative Commons 3.0 BY.
 * 
 * Полный текст лицензии находится в файле LICENSE.TXT.
 * 
 * Официальный блог EasyCoding Team: http://www.easycoding.org/
 * Официальная страница проекта: http://www.easycoding.org/projects/gchclient
*/
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Ionic.Zip;
using gchcore;

namespace gchupdater
{
    public sealed class Program
    {
        private static void DownloadUpdate(string Url, string Dest, string BinFile)
        {
            // Получаем имя файла...
            string DestFile = Path.GetFileName(Url);
            Console.WriteLine();
            Console.Write(Properties.Resources.ConDownFrmServer, DestFile);

            // Загружаем и проверяем загрузился ли он...
            if (CoreLib.DownloadRemoteFile(Url, Path.Combine(Dest, DestFile), Properties.Resources.AppUserAgent))
            {
                Console.WriteLine(Properties.Resources.ConDone);
                Console.Write(Properties.Resources.ConUpdatingFiles);
                
                // Распаковываем загруженный zip-архив...
                using (ZipFile zip = ZipFile.Read(Path.Combine(Dest, DestFile)))
                {
                    foreach (ZipEntry e in zip)
                    {
                        try
                        {
                            e.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                            e.Extract(Dest);
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine(Properties.Resources.ConExError, Ex.Message);
                        }
                    }
                }
                // Выводим сообщения...
                Console.WriteLine(Properties.Resources.ConDone);
                Console.WriteLine();
                Console.WriteLine(Properties.Resources.ConUpdateFinished);
                Console.WriteLine();
                
                // Удаляем временный файл (загруженный архив)...
                Console.Write(Properties.Resources.ConRemovingTempFiles);
                File.Delete(Path.Combine(Dest, DestFile));
                Console.WriteLine(Properties.Resources.ConDone);

                // Запускаем полученный бинарник...
                try { Process.Start(Path.Combine(Dest, BinFile)); } catch (Exception Ex) { Console.WriteLine(Ex.Message); }
            }
            else
            {
                Console.WriteLine(Properties.Resources.ConErrText);
            }
        }

        private static void Main(string[] args)
        {
            // Получим кататалог запуска приложения...
            string AppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // Зададим заголовок консоли и цвет...
            Console.Title = Properties.Resources.ConTitle;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            // Выведем приветствие...
            Console.WriteLine(CoreLib.GetTemplateFromResource(Properties.Resources.WlcMsgResName));

            // Проверим наличие параметров командной строки...
            if (args.Count() == 1)
            {
                // Обходим блокировку процесса при обновлении...
                if (Path.GetFileName(Assembly.GetEntryAssembly().Location) != Properties.Resources.UpdateFile)
                {                    
                    try
                    {
                        if (File.Exists(Path.Combine(AppPath, Properties.Resources.UpdateFile))) { File.Delete(Path.Combine(AppPath, Properties.Resources.UpdateFile)); }
                        File.Copy(Path.Combine(AppPath, Assembly.GetEntryAssembly().Location), Path.Combine(AppPath, Properties.Resources.UpdateFile), true);
                        Console.WriteLine(Properties.Resources.ConStartWorker);
                        Process.Start(Path.Combine(AppPath, Properties.Resources.UpdateFile), args[0]);
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                    Environment.Exit(5);
                }
                else
                {
                    // Проверим существование бинарника...
                    if (File.Exists(Path.Combine(AppPath, args[0])))
                    {
                        // Получим текущую версию клиента...
                        FileVersionInfo GchCl = FileVersionInfo.GetVersionInfo(Path.Combine(AppPath, args[0]));
                        Console.WriteLine(Properties.Resources.ConCurrVer, GchCl.FileVersion);
                        
                        try
                        {
                            // Получим версию с сервера...
                            Updater UpMan = new Updater(args[0], Properties.Resources.AppUserAgent);

                            // Выводим информацию о доступной версии...
                            Console.WriteLine(Properties.Resources.ConNewVer, UpMan.AppUpdateVersion);
                            Console.WriteLine();

                            // Проверяем старую и новую версии...
                            if (UpMan.CheckAppUpdate())
                            {
                                // Есть обновление, качаем. Выводим информацию в консоль...
                                Console.WriteLine(Properties.Resources.ConUpdateAvail);

                                // Завершим процесс обновляемого приложения...
                                CoreLib.ProcessTerminate(args[0]);

                                // Загружаем обновление...
                                DownloadUpdate(UpMan.AppUpdateURL, AppPath, args[0]);
                            }
                            else
                            {
                                // Новых обновлений нет. Выводим информацию об этом...
                                Console.WriteLine(Properties.Resources.ConNoUpdatesAvail);
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine(Properties.Resources.ConCritError, Ex.Message);
                        }
                    }
                    else
                    {
                        // Не нашли, поэтому обновлять нечего...
                        Console.WriteLine(Properties.Resources.ConNoBinFound);
                    }

                    Console.WriteLine();
                    Console.WriteLine(Properties.Resources.ConGb);
                }
            }
            else
            {
                Console.WriteLine(Properties.Resources.ConNoDirectStart);
            }
            
            #if DEBUG
            Console.ReadKey();
            #endif
        }
    }
}
