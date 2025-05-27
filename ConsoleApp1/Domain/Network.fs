namespace ConsoleApp.Domain

module Network =
    type NetworkInfo = {
        ipAddres: string list
        macAddr: string
    }

    type INetworkRepository =
        abstract member GetNetwork : unit -> NetworkInfo list 
