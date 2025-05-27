namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.Disk
open ConsoleApp.Application.Ports.Disk

module Disk =
    type DiskService(repo: IDiskRepository) =
        interface IDiskService with
            member _.GetDiskInfo (): unit = 
                repo.GetDisk()
                |> JsonSerializer.Serialize
                |> (fun x -> File.WriteAllText("diskInfo.json", x))

