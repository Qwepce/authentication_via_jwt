# Аутентификация пользователя в приложении ASP\.NET при помощи JWT-токена

**В проекте есть две ветки, main (только регистрация и аутентификация) и feature/authorization (настроена авторизация через роли и политики)**

* Простой пример настройки регистрации и аутентификации пользователей с сохранением записей в базе данных.
* После успешного логина JWT-токен кладётся в куки пользователя, позволяя ему обращаться по тем адресам, для которых требуется аутентификация.
* В папке docs лежат скриншоты алгоритма аутентификации пользователя.

1. Стартовые эндпоинты приложения 
![endpoints](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/endpoints.png)
2. Статус 401 на эндпоинте, который требует аутентификации перед обращением
![unauthorized](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/status_401.png)
3. Регистрация пользователя в приложении
![register-user](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/register.png)
4. Хранение записи в БД (пароль захэширован алгоритмом SHA256)
![db-record](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/db_record.png)
5. При успешном логине кладём в куки юзера сгенерированный JWT-token
![new-cookies](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/added_cookies.png)
6. Затем в конфиге проверяем Header на наличие такого кукиса: если есть - пускаем юзера
![status-200](https://github.com/Qwepce/authentication_via_jwt/blob/main/docs/status_200.png)
***
Стек:
1. \.net 8.0
2. ASP\.NET
3. MsSql
(P.S. по планам дописать авторизацию, refresh-token + посмотреть в сторону keycloak'a)
