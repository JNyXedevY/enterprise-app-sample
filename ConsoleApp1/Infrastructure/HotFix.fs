namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.HotFix

module HotFix  =
    type WmiHotFixRepository() =
        interface IHotFixRepository with
            member _.GetHotFix (): HotFixInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_QuickFixEngineering")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    hotFixId = obj.["HotFixID"] :?> string
                    installDateTime = obj.["InstalledOn"] :?> string
                })
                |> Seq.toList
