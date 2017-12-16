echo off
echo
chcp 866
echo
echo Удаление каталога пользователя CVZ ...
echo
rd /S /Q c:\users\CVZ

taskkill /T /IM microsip*

echo Копирование ярлыков и файла настройки LiveWebCam и преднастройки MicroSip ...
echo
robocopy %~dp0\С\ C:\ *.* /E 

pause