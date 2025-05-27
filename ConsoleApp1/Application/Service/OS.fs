namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.OS
open ConsoleApp.Application.Ports.OS

module OS =
    type OSService(repo:  IOsRepository) =
        interface IOsService with
            member _.GetOsInfo (): unit = 
                repo.GetOs()
                |> JsonSerializer.Serialize
                |> (fun x -> File.WriteAllText("osInfo.json", x))
