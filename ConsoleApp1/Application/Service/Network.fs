namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.Network
open ConsoleApp.Application.Ports.Network

module Network =
    type NetworkService(repo: INetworkRepository) =
        interface INetworkService with
            member _.GetNetworkInfo (): unit = 
                repo.GetNetwork()
                |> JsonSerializer.Serialize
                |> (fun x -> File.WriteAllText("networkInfo.json", x))

