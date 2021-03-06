Garant Checker Offline [![Build Status](https://travis-ci.org/xvitaly/gchclient.svg?branch=master)](https://travis-ci.org/xvitaly/gchclient)
=========

**Garant Checker Offline** (служба проверки пользователей) — клиент, демонстрирующий работу с [API](http://www.easycoding.org/projects/gchecker/api) проекта [PHP Garant Checker](http://www.easycoding.org/projects/gchecker). Программа написана исключительно for fun для гарантов и пользователей [форума team-fortress.su](http://forum.team-fortress.su/).

Данное приложение предназначено для гарантов и пользователей, которые вынуждены проверять десятки или даже сотни пользовательских профилей Steam на наличие в чёрном/белом списках, гарантах и т.д.

Сообщить об ошибке в программе, а также предложить новую функцию можно здесь: https://github.com/xvitaly/gchclient/issues

**Лицензия**: GNU General Public License версии 3.

**Поддерживаемые платформы**: Windows 7 SP1 — 10 (все редакции, кроме Starter).

**Зависимости**: [Microsoft .NET Framework 4.6.1](https://www.microsoft.com/ru-RU/download/details.aspx?id=49981) и выше (не требуется при запуске в Windows 8+).

Скачать
=========
Скачать приложение можно в разделе [Релизы](https://github.com/xvitaly/gchclient/releases), либо с [официального сайта](https://www.easycoding.org/projects/gchclient) проекта.

Основные функции
=========
 * полностью автоматическая проверка URL на профили Steam из буфера обмена;
 * автоматический резолвинг SteamID и неизменяемых ID с любых Steam URL;
 * вывод аватара, текущего состояния (онлайн, в игре или отключён) и ника проверяемой учётной записи;
 * поддержка работы через безопасные соединения (SSL);
 * кэширование аватаров;
 * отображение принадлежности пользователя к спискам;
 * проверка на ограниченные аккаунты Steam (аккаунты без купленных игр);
 * вывод статуса VAC;
 * вывод статуса торговли;
 * возможность проверить друзей пользователя (для открытых профилей);
 * возможность быстрого добавления пользователя в список друзей и отправки ему сообщения (вы должны состоять с ним в одной группе, либо находиться в друзьях);
 * возможность быстро открыть рюкзак TF2 проверяемого пользователя;
 * вызов/скрытие чекера по «горячей клавише» (по умолчанию F11);
 * встроенный модуль просмотра доказательств.
