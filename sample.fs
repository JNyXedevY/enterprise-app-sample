open System
open System.Management


[<EntryPoint>]
let main args =
    let computerSearch = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
    for mo in computerSearch.Get() do
        printfn "メーカー: %s" (mo.["Manufacturer"] |> string)
        printfn "モデル: %s" (mo.["Model"] |> string)
        printfn "ユーザー名: %s" (mo.["UserName"] |> string)
        printfn "システムタイプ: %s" (mo.["SystemType"] |> string)

    let osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
    for os in osSearcher.Get() do
        printfn "OS名: %s" (os.["Caption"] |> string)
        printfn "バージョン: %s" (os.["Version"] |> string)
        printfn "アーキテクチャ: %s" (os.["OSArchitecture"] |> string)
        printfn "インストール日時: %s" (os.["InstallDate"] |> string)

    let networkSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE")
    for net in networkSearcher.Get() do
        printfn "IPアドレス: %s" (net.["IPAddress"] |> string)
        printfn "MACアドレス: %s" (net.["MACAddress"] |> string)
        printfn "DHCP有効: %s" (net.["DHCPEnabled"] |> string)

    let diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 3")
    for disk in diskSearcher.Get() do
        printfn "ドライブ: %s" (disk.["DeviceID"] |> string)
        printfn "ファイルシステム: %s" (disk.["FileSystem"] |> string)
        printfn "総容量: %s バイト" (disk.["Size"] |> string)
        printfn "空き容量: %s バイト" (disk.["FreeSpace"] |> string)

    let driveSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
    for drive in driveSearcher.Get() do
        printfn "ディスクモデル: %s" (drive.["Model"] |> string)
        printfn "インターフェース: %s" (drive.["InterfaceType"] |> string)
        printfn "シリアル番号: %s" (drive.["SerialNumber"] |> string)

    let userSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount")
    for user in userSearcher.Get() do
        printfn "ユーザー名: %s" (user.["Name"] |> string)
        printfn "ドメイン: %s" (user.["Domain"] |> string)

    let FixSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_QuickFixEngineering")
    for update in FixSearcher.Get() do
        printfn "更新プログラム: %s" (update.["HotFixID"] |> string)
        printfn "インストール日: %s" (update.["InstalledOn"] |> string)

    let ServiceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service")
    for service in ServiceSearcher.Get() do
        printfn "サービス名: %s" (service.["Name"] |> string)
        printfn "表示名: %s" (service.["DisplayName"] |> string)
        printfn "状態: %s" (service.["State"] |> string)
        printfn "スタートアップの種類: %s" (service.["StartMode"] |> string)


    0
