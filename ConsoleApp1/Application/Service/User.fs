namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.User
open ConsoleApp.Application.Ports.User

module User =
    type UserService(repo: IUserRepository) =
        interface IUserService with
            member _.GetUserInfo (): unit = 
                repo.GetUser()
                |> JsonSerializer.Serialize
                |> (fun x -> File.WriteAllText("userInfo.json", x))

