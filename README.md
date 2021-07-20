# WebHookService
Задание

Создано приложение ASP.NET Core WEB API, в котором пользователь может войти в приложение и подписаться на вебхуки, а затем сгенерировать API, и он получит собственную аналитику. 
Были подключены необходимые пакеты для разработки приложения.
Реализована регистрация и авторизация пользователя. После того, как человек зарегистрировался, он переходит на сервис.
Создана база данных WebhooksDB. Все вебхуки сохраняются в бд. Ее копия прикреплина на всякий случай, если вдруг студия будет чудить. Иногда локально не подключается.
Реализованы разные методы. Протестированы с помощью Postman.

Посмотрев на страницу панели инструментов, мы увидим, что у нас есть меню «Создать ключ API». 
Затем для генерации ссылки мы собираемся выбрать Service и Max Request и нажать кнопку «Create API Key», чтобы сгенерировать ключ.
Добавлен контроллер хранилища сервисов, который будет отображать все вебхуки на нем. После нажатия на эту службу мы увидим свой ключ API для этого вебхука.
Теперь, щелкнув ссылку сервиса Webhooks API, мы увидим подробное представление сервиса с API-ключом для него.
Здесь у нас есть возможность деактивировать ссылку и повторно активировать ссылку, также нажав кнопку деактивировать.
Мы предоставили функцию для активации и деактивации ссылки, затем мы подошли к основному процессу проверки запроса API, и выполнили регистрацию каждого запроса. Таким образом, разработчик или обычный пользователь знает, сколько раз запрашивался API.

В контроллере ServicesStore у нас есть два метода действий. Оба являются методами [HttpGet], один для отображения службы (Service) в представлении, а другой для отображения деталей (Details) этого сервиса.
Сделаны два графика запросов для Webhooks и Url. По ним мы можем посмотреть по какой ссылке сколько было запросов и в какое время. Дата начала январь, конец декабрь года.
Эти диаграммы показаны на основе данных, которые регистрируются в каждом запросе.
Папка Filters содержит фильтр для проверки сеанса пользователя. Также есть папка промежуточного программного обеспечения, и репозиторий для хранения интерфейса и классов concrete. Это основная часть, чтобы показать rest методы, генерацию, графики, интерфейс и в целом работу сервиса.
Интерфейс сервиса адаптивный.
А для работы с запросами подключила Swagger для удобного просмотра request details Api, потому что пыталась реализовать эту часть сервиса сама во втором проекте,более подробно по запросам, чтобы тут не убить все. Он находится в архиве .zip1. На гит полносто почему-то не все загружалось. Надеюсь в архиве тоже нормально все.
Там конечно много косяков, но пыталась доделать по интерфейсу и подробные детали по запросам. Некоторые ошибки не получилось пофиксить, приходилось обходить их, но не все успешно. Как-то так получилось. В image есть несколько скринов.
