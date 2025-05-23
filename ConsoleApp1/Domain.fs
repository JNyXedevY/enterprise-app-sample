module Domain

    type DeviceInfo = {
        manufacturer: string
        model: string
        userName: string
        systemType: string
     }

    type OsInfo = {
        name: string
        version: string
        arch: string
        installDateTime: string
     }

    type NetworkInfo = {
        ipAddr: string list
        macAddr: string
     }

    type DiskInfo = {
        deviceId: string
        fileSystem: string
        maxSize: uint64
        freeSize: uint64
     }

    type UserInfo = {
        userName: string
        userDomain: string
     }

    type HotFixInfo = {
        hotFixId: string
        installDateTime: string
     }

    type ServiceInfo = {
        name: string
        displayName: string
        state: string
        startMode: string
     }

    type AppInfo = {
        name: string
        version: string
        installDate: string
     }

    type BatteryInfo = {
        name: string
        status: string
        designCapacity: int64 option
        fullChargeCapacity: int64 option
     }

