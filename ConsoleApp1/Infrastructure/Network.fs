namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.Network

module Network =
    type WmiNetworkRepository() =
        interface INetworkRepository with
            member _.GetNetwork (): NetworkInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    ipAddres = obj.["IPAddress"] :?> string[] |>  List.ofArray
                    macAddr = obj.["MACAddress"] :?> string
                })
                |> Seq.toList
