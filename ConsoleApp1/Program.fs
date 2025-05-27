open ConsoleApp.Application.Service
open ConsoleApp.Application.Ports
open ConsoleApp.Infrastructure
open ConsoleApp.Domain

[<EntryPoint>]
let main args =
    let deviceRepo = Device.WmiDeviceRepository()
    let osRepo = OS.WmiOsRepository()
    let networkRepo = Network.WmiNetworkRepository()
    let diskRepo = Disk.WmiDiskRepository()
    let userRepo = User.WmiUserRepository()
    let hotfixRepo = HotFix.WmiHotFixRepository()

    let deviceService : Device.IDeviceService = Device.DeviceService(deviceRepo)
    let osService : OS.IOsService  = OS.OSService(osRepo)
    let networkService : Network.INetworkService = Network.NetworkService(networkRepo)
    let diskService : Disk.IDiskService = Disk.DiskService(diskRepo)
    let userService : User.IUserService = User.UserService(userRepo)
    let hotfixService : HotFix.IHotFixService = HotFix.HotFixService(hotfixRepo)

    deviceService.GetDeviceInfo()
    osService.GetOsInfo()
    networkService.GetNetworkInfo()
    diskService.GetDiskInfo()
    userService.GetUserInfo()
    hotfixService.GetHotFixInfo()

    0
