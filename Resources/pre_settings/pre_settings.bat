echo off
echo
chcp 866
echo
echo �������� ��⠫��� ���짮��⥫� CVZ ...
echo
rd /S /Q c:\users\CVZ

taskkill /T /IM microsip*

echo ����஢���� ��몮� � 䠩�� ����ன�� LiveWebCam � �।����ன�� MicroSip ...
echo
robocopy %~dp0\�\ C:\ *.* /E 

pause