$IpAddresses = (Get-NetIPAddress).IPAddress       # Get all IP adresses of the host
$IpAddress = $IpAddresses -match "^10\."          # Match the necessary subnet (10.x.x.x)

if ([string]::IsNullOrEmpty($IpAddress)){         # Check if IP Address was macthed
    echo "Invalid IP address"
    exit 1
}

$TmpIpAddress = $IpAddress.Split('.')             # Explode IP address by . to tokens
$TmpIpAddress[-1] = 251                           # Replace the last octet to 251 (camera address)
$CamIpAddress = $TmpIpAddress -join '.'           # Assebme IP address from exploded tokens

   

[void][Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic')                                                                             # Modal dialog with CVZ number question


$Cvz = get-childitem -path env:computername | Select-Object Value                                                                                     # Get hostname
                                                                                                      
$CvzSplit = $Cvz.Value[5..7]                                                                                                                          #Slice by cvz name
$CvzName = $CvzSplit -join ''                                                                                                                         # Assemble CVZ name


$title = 'Диск для записи архива'                                                                                                                     # Window title
$msg   = 'Введите букву диска для записи архива (например "C" или "D"):'                                                                              # Window text
$DiskName = [Microsoft.VisualBasic.Interaction]::InputBox($msg, $title)                                                                               # Show window and capture an answer
   
if ($DiskName -eq "D"){                                                                                                                                # If disk name is D then copy video folder with permissions
    xcopy C:\Video D:\Video /e /i /h /x /o
}

(Get-Content $env:APPDATA\iSpy\XML\objects.xml).replace('XXX', $CvzName) | Set-Content $env:APPDATA\iSpy\XML\objects.xml                         # Replace camera IP adress in config files
(Get-Content $env:APPDATA\iSpy\XML\objects.xml).replace('10.X.X.X', $CamIpAddress) | Set-Content $env:APPDATA\iSpy\XML\objects.xml               # Replace CVZ name on camera

(Get-Content $env:APPDATA\iSpy\XML\config.xml).replace('X.X.X.X', $IpAddress) | Set-Content $env:APPDATA\iSpy\XML\config.xml          # Replace host IP adress in config files
(Get-Content $env:APPDATA\iSpy\XML\config.xml).replace('10.X.X.X', $CamIpAddress) | Set-Content $env:APPDATA\iSpy\XML\config.xml      # Replace camera IP adress in config files
(Get-Content $env:APPDATA\iSpy\XML\config.xml).replace('_X', $DiskName) | Set-Content $env:APPDATA\iSpy\XML\config.xml                # Replace disk name for video archive folder

($TaskScheduler = New-Object -ComObject Schedule.Service).Connect("localhost")                                                        # Enable scheduler task
$MyTask = $TaskScheduler.GetFolder('\').GetTask("CAM")
$MyTask.Enabled = $true