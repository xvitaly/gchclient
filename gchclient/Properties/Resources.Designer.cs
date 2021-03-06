﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gchclient.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("gchclient.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}check.team-fortress.su/personal.
        /// </summary>
        internal static string APIRepURL {
            get {
                return ResourceManager.GetString("APIRepURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}check.team-fortress.su/api.php?action={1}&amp;token={2}&amp;id={3}.
        /// </summary>
        internal static string APIURI {
            get {
                return ResourceManager.GetString("APIURI", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to steam://friends/add/{0}.
        /// </summary>
        internal static string AppAddTemplate {
            get {
                return ResourceManager.GetString("AppAddTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внимание! Один экземпляр программы уже запущен. Иконка программы расположена в системном трее, около часов Windows..
        /// </summary>
        internal static string AppAlrLaunched {
            get {
                return ResourceManager.GetString("AppAlrLaunched", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Комбинация клавиш, необходимых для работы программы, уже зарегистрирована в системе. Работа данного экземпляра будет прекращена!.
        /// </summary>
        internal static string AppAlrRun {
            get {
                return ResourceManager.GetString("AppAlrRun", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ^(http|https)://(www.|)(steamcommunity|tf2items|steamrep|tf2b).com/(id|profiles)/.
        /// </summary>
        internal static string AppChkRegEx {
            get {
                return ResourceManager.GetString("AppChkRegEx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;(.|\n)*?&gt;.
        /// </summary>
        internal static string AppEntCleanRegex {
            get {
                return ResourceManager.GetString("AppEntCleanRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка при получении информации о вашем токене доступа. Повторите попытку позднее!.
        /// </summary>
        internal static string AppErrTokenInfo {
            get {
                return ResourceManager.GetString("AppErrTokenInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Вы не ввели ссылку, либо ID для проверки. Проверка невозможна. Введите условие и повторите попытку..
        /// </summary>
        internal static string AppFieldEmpty {
            get {
                return ResourceManager.GetString("AppFieldEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Данный профиль скрыт, либо имеет статус &quot;Только для друзей&quot;. Отображение списка друзей для него недоступно..
        /// </summary>
        internal static string AppFrErr {
            get {
                return ResourceManager.GetString("AppFrErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Программа была свёрнута в трей, но продолжает работу. Дважды щёлкните по значку для восстановления окна. Для выхода нажмите правой кнопкой и Выход..
        /// </summary>
        internal static string AppHideTray {
            get {
                return ResourceManager.GetString("AppHideTray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка при вставке из буфера обмена!.
        /// </summary>
        internal static string AppIgnClipbErr {
            get {
                return ResourceManager.GetString("AppIgnClipbErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Запрещено удалять элементы, созданные не лично вами!.
        /// </summary>
        internal static string AppIgnLDlEx {
            get {
                return ResourceManager.GetString("AppIgnLDlEx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Очистить окно редактора?.
        /// </summary>
        internal static string AppIgnLDMsg {
            get {
                return ResourceManager.GetString("AppIgnLDMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .(png|jpg|jpeg|gif)$.
        /// </summary>
        internal static string AppImageRegex {
            get {
                return ResourceManager.GetString("AppImageRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Вы ввели недействительные токены авторизации. Сервер вернул код ответа 403 - Запрещено. Обратитесь на форум TEAM-FORTRESS.SU..
        /// </summary>
        internal static string AppIncorrectTokens {
            get {
                return ResourceManager.GetString("AppIncorrectTokens", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to gchk.
        /// </summary>
        internal static string AppIntName {
            get {
                return ResourceManager.GetString("AppIntName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Постоянная ссылка на аккаунт пользователя была успешно скопирована в буфер обмена!.
        /// </summary>
        internal static string AppMSGLnkCopClipb {
            get {
                return ResourceManager.GetString("AppMSGLnkCopClipb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Никнейм пользователя был успешно помещён в буфер обмена Windows!.
        /// </summary>
        internal static string AppMsgNicknClipb {
            get {
                return ResourceManager.GetString("AppMsgNicknClipb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SteamID пользователя {0} был успешно помещён в буфер обмена Windows!.
        /// </summary>
        internal static string AppMsgSiDClipb {
            get {
                return ResourceManager.GetString("AppMsgSiDClipb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Служба проверки пользователей.
        /// </summary>
        internal static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UNKNOWN.
        /// </summary>
        internal static string AppNicknameUnknown {
            get {
                return ResourceManager.GetString("AppNicknameUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не заданы токены авторизации в настройках. Проверка невозможна. Задайте их и повторите попытку!.
        /// </summary>
        internal static string AppNoTokensErr {
            get {
                return ResourceManager.GetString("AppNoTokensErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не обнаружен модуль обновления! Возможно, программа установлена не полностью. Загрузите новую версию самостоятельно с официального сайта..
        /// </summary>
        internal static string AppNoUpdater {
            get {
                return ResourceManager.GetString("AppNoUpdater", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка во время перехода по ссылке!.
        /// </summary>
        internal static string AppNoURLStr {
            get {
                return ResourceManager.GetString("AppNoURLStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ^http://steamcommunity.com/profiles/.
        /// </summary>
        internal static string AppProfileRegex {
            get {
                return ResourceManager.GetString("AppProfileRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Построение списка....
        /// </summary>
        internal static string AppSBBuilding {
            get {
                return ResourceManager.GetString("AppSBBuilding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Готов..
        /// </summary>
        internal static string AppSBReady {
            get {
                return ResourceManager.GetString("AppSBReady", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Получение информации с сервера....
        /// </summary>
        internal static string AppSBReceiving {
            get {
                return ResourceManager.GetString("AppSBReceiving", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Заполните необходимые поля! Если у Вас нет токенов авторизации, обратитесь на форум TEAM-FORTRESS.SU..
        /// </summary>
        internal static string AppSettEmptyS {
            get {
                return ResourceManager.GetString("AppSettEmptyS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Настройки успешно сохранены!.
        /// </summary>
        internal static string AppSettSaved {
            get {
                return ResourceManager.GetString("AppSettSaved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка при вызове Интернет-браузера. Переустановите его, либо назначьте браузер по умолчанию!.
        /// </summary>
        internal static string AppStartFailure {
            get {
                return ResourceManager.GetString("AppStartFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Доступно обновление программы до версии {0}. Нажмите на это сообщение для обновления..
        /// </summary>
        internal static string AppUpdateAvailable {
            get {
                return ResourceManager.GetString("AppUpdateAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка при вызове обработчика протокола. Убедитесь в корректной установке клиента Steam..
        /// </summary>
        internal static string AppURIStartFail {
            get {
                return ResourceManager.GetString("AppURIStartFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (?&lt;url&gt;((http|https):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[-]|[?]|[=]|[#]|[~]|[_]|[:])*).
        /// </summary>
        internal static string AppURLRegex {
            get {
                return ResourceManager.GetString("AppURLRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mozilla/5.0 (Windows NT 5.1; rv:10.0.7) Gecko/20100101 Firefox/10.0.7.
        /// </summary>
        internal static string AppUserAgent {
            get {
                return ResourceManager.GetString("AppUserAgent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Программа уже занята обработкой предыдущего запроса. Пожалуйста, повторите попытку позднее..
        /// </summary>
        internal static string AppWorkerBusy {
            get {
                return ResourceManager.GetString("AppWorkerBusy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap avatarholder {
            get {
                object obj = ResourceManager.GetObject("avatarholder", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap clock {
            get {
                object obj = ResourceManager.GetObject("clock", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кастомное описание и дополнительная информация для этого пользователя отсутствуют..
        /// </summary>
        internal static string CustInfoNone {
            get {
                return ResourceManager.GetString("CustInfoNone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Профиль запрошенного пользователя не существует!.
        /// </summary>
        internal static string ErrNotExists {
            get {
                return ResourceManager.GetString("ErrNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Бесплатный аккаунт..
        /// </summary>
        internal static string F2PAccTextStatus {
            get {
                return ResourceManager.GetString("F2PAccTextStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap iconAddFriend {
            get {
                object obj = ResourceManager.GetObject("iconAddFriend", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap iconInventory {
            get {
                object obj = ResourceManager.GetObject("iconInventory", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap iconReport {
            get {
                object obj = ResourceManager.GetObject("iconReport", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to В буфере обмена находится неверный URL! Проверка не будет выполнена..
        /// </summary>
        internal static string IncorrectURL {
            get {
                return ResourceManager.GetString("IncorrectURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ЧС.
        /// </summary>
        internal static string ListBlackName {
            get {
                return ResourceManager.GetString("ListBlackName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ЧС аук.
        /// </summary>
        internal static string ListBlAucName {
            get {
                return ResourceManager.GetString("ListBlAucName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Гаранты.
        /// </summary>
        internal static string ListGarantName {
            get {
                return ResourceManager.GetString("ListGarantName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Нет.
        /// </summary>
        internal static string ListNoneName {
            get {
                return ResourceManager.GetString("ListNoneName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ненадёжные.
        /// </summary>
        internal static string ListNotTrName {
            get {
                return ResourceManager.GetString("ListNotTrName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Премиум.
        /// </summary>
        internal static string ListPremName {
            get {
                return ResourceManager.GetString("ListPremName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Staff.
        /// </summary>
        internal static string ListStaffName {
            get {
                return ResourceManager.GetString("ListStaffName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to БС.
        /// </summary>
        internal static string ListWhiteName {
            get {
                return ResourceManager.GetString("ListWhiteName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap message {
            get {
                object obj = ResourceManager.GetObject("message", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap null_avatar {
            get {
                object obj = ResourceManager.GetObject("null_avatar", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не заполнены требуемые поля. Заполните и повторите попытку!.
        /// </summary>
        internal static string RepEmptyField {
            get {
                return ResourceManager.GetString("RepEmptyField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка при отправке сообщения. Повторите попытку позднее!.
        /// </summary>
        internal static string RepError {
            get {
                return ResourceManager.GetString("RepError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Отправил пользователь оффлайнового чекера с API.
        /// </summary>
        internal static string RepPostFix {
            get {
                return ResourceManager.GetString("RepPostFix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ваше сообщение было успешно отправлено и будет рассмотрено администраторами в ближайшее время!.
        /// </summary>
        internal static string RepSubmitted {
            get {
                return ResourceManager.GetString("RepSubmitted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to +.
        /// </summary>
        internal static string SCAdded {
            get {
                return ResourceManager.GetString("SCAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -.
        /// </summary>
        internal static string SCDeleted {
            get {
                return ResourceManager.GetString("SCDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @@#.
        /// </summary>
        internal static string SCDelim {
            get {
                return ResourceManager.GetString("SCDelim", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to =.
        /// </summary>
        internal static string SCEqual {
            get {
                return ResourceManager.GetString("SCEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to n/a.
        /// </summary>
        internal static string SCUnknown {
            get {
                return ResourceManager.GetString("SCUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap search {
            get {
                object obj = ResourceManager.GetObject("search", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap srchfr {
            get {
                object obj = ResourceManager.GetObject("srchfr", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap task {
            get {
                object obj = ResourceManager.GetObject("task", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Игровые баны: {0}..
        /// </summary>
        internal static string TemplateGameBans {
            get {
                return ResourceManager.GetString("TemplateGameBans", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to отсутствуют.
        /// </summary>
        internal static string TemplateGameBansNo {
            get {
                return ResourceManager.GetString("TemplateGameBansNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to есть - {0}.
        /// </summary>
        internal static string TemplateGameBansYes {
            get {
                return ResourceManager.GetString("TemplateGameBansYes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Статус на сайте: {0}..
        /// </summary>
        internal static string TemplateInternal {
            get {
                return ResourceManager.GetString("TemplateInternal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://steamcommunity.com/profiles/{0}/inventory/.
        /// </summary>
        internal static string TemplateInvSteam {
            get {
                return ResourceManager.GetString("TemplateInvSteam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://tf2b.com/tf2/{0}.
        /// </summary>
        internal static string TemplateInvTF2b {
            get {
                return ResourceManager.GetString("TemplateInvTF2b", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://www.tf2items.com/profiles/{0}.
        /// </summary>
        internal static string TemplateInvTF2Items {
            get {
                return ResourceManager.GetString("TemplateInvTF2Items", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://www.tf2outpost.com/backpack/{0}/.
        /// </summary>
        internal static string TemplateInvTF2Outpost {
            get {
                return ResourceManager.GetString("TemplateInvTF2Outpost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Статус SteamRep: {0}..
        /// </summary>
        internal static string TemplateSteamRep {
            get {
                return ResourceManager.GetString("TemplateSteamRep", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to мошенник.
        /// </summary>
        internal static string TemplateTFSUBlack {
            get {
                return ResourceManager.GetString("TemplateTFSUBlack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ЧС аукциона.
        /// </summary>
        internal static string TemplateTFSUBlackAuc {
            get {
                return ResourceManager.GetString("TemplateTFSUBlackAuc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ненадёжный.
        /// </summary>
        internal static string TemplateTFSUGray {
            get {
                return ResourceManager.GetString("TemplateTFSUGray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to гарант.
        /// </summary>
        internal static string TemplateTFSUMiddle {
            get {
                return ResourceManager.GetString("TemplateTFSUMiddle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to нет в базе.
        /// </summary>
        internal static string TemplateTFSUNeutral {
            get {
                return ResourceManager.GetString("TemplateTFSUNeutral", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to премиум-пользователь.
        /// </summary>
        internal static string TemplateTFSUPrem {
            get {
                return ResourceManager.GetString("TemplateTFSUPrem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to сотрудник.
        /// </summary>
        internal static string TemplateTFSUStaff {
            get {
                return ResourceManager.GetString("TemplateTFSUStaff", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to НЕВЕРНЫЙКОД.
        /// </summary>
        internal static string TemplateTFSUUnknown {
            get {
                return ResourceManager.GetString("TemplateTFSUUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to в белом списке.
        /// </summary>
        internal static string TemplateTFSUWhite {
            get {
                return ResourceManager.GetString("TemplateTFSUWhite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Является сотрудником сайта TEAM-FORTRESS.SU..
        /// </summary>
        internal static string TFStaff {
            get {
                return ResourceManager.GetString("TFStaff", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Дополнительная информация об этом пользователе недоступна!.
        /// </summary>
        internal static string TFStaffMsg {
            get {
                return ResourceManager.GetString("TFStaffMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to отключён.
        /// </summary>
        internal static string TradeBanned {
            get {
                return ResourceManager.GetString("TradeBanned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to испытат. срок.
        /// </summary>
        internal static string TradeIsp {
            get {
                return ResourceManager.GetString("TradeIsp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to без ограничений.
        /// </summary>
        internal static string TradeNormal {
            get {
                return ResourceManager.GetString("TradeNormal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Трейд: {0}..
        /// </summary>
        internal static string TradeST {
            get {
                return ResourceManager.GetString("TradeST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось установить принадлежность этого пользователя. Обновите клиент!.
        /// </summary>
        internal static string UnknownGroup {
            get {
                return ResourceManager.GetString("UnknownGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Контрольная сумма загруженного файла отличается от эталона. Обновление не было установлено!.
        /// </summary>
        internal static string UPD_HashFailure {
            get {
                return ResourceManager.GetString("UPD_HashFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка при попытке запуска программы установки новой версии. Программа не была обновлена. Запустите обновление повторно позднее!.
        /// </summary>
        internal static string UPD_UpdateFailure {
            get {
                return ResourceManager.GetString("UPD_UpdateFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Новая версия была успешно получена с сервера. Сейчас будет произведена её установка!.
        /// </summary>
        internal static string UPD_UpdateSuccessful {
            get {
                return ResourceManager.GetString("UPD_UpdateSuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Статус VAC: {0}..
        /// </summary>
        internal static string VCStatusA {
            get {
                return ResourceManager.GetString("VCStatusA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to забанен.
        /// </summary>
        internal static string VCStatusBanned {
            get {
                return ResourceManager.GetString("VCStatusBanned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to чист.
        /// </summary>
        internal static string VCStatusNormal {
            get {
                return ResourceManager.GetString("VCStatusNormal", resourceCulture);
            }
        }
    }
}
