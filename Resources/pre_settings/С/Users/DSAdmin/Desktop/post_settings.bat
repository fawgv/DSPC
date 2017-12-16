robocopy "C:\Users\DSadmin\AppData\Roaming\Thunderbird" "C:\Users\Default\AppData\Roaming\Thunderbird" *.* /E
robocopy "C:\Users\DSadmin\AppData\Roaming\NAPS2" "C:\Users\Default\AppData\Roaming\NAPS2" *.* /E
robocopy "C:\Users\DSadmin\AppData\Roaming\MicroSIP" "C:\Users\Default\AppData\Roaming\MicroSIP" *.* /E
robocopy "C:\Users\DSAdmin\AppData\Local\Google" "C:\Users\Default\AppData\Local\Google" *.*
robocopy "C:\Users\DSadmin\AppData\Roaming\iSpy\XML" "C:\Users\Default\AppData\Roaming\iSpy\XML" *.*
robocopy "C:\Users\DSadmin\AppData\Local\VirtualStore\Program Files (x86)\SHTRIH-M" "C:\Users\Default\AppData\Local\VirtualStore\Program Files (x86)\SHTRIH-M" *.*
robocopy "C:\Users\DSadmin\AppData\Roaming\Kyocera" "C:\Users\Default\AppData\Roaming\Kyocera" *.* /E

del "c:\Users\default\Desktop\iSpy.lnk"
del "c:\Users\default\Desktop\Copy Files.lnk"
del "c:\Users\dsadmin\Desktop\iSpy.lnk"
del "c:\Users\dsadmin\Desktop\Copy Files.lnk"

pause