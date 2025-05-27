namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.HotFix
open ConsoleApp.Application.Ports.HotFix

module HotFix =
    type HotFixService(repo: IHotFixRepository) =
        interface IHotFixService with
            member _.GetHotFixInfo (): unit = 
                repo.GetHotFix()
                |> JsonSerializer.Serialize
                |> (fun x -> File.WriteAllText("hotfixInfo.json", x))
