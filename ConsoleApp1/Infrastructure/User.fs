namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.User

module User =
    type WmiUserRepository() =
        interface IUserRepository with
            member _.GetUser (): UserInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    userName = obj.["Name"] :?> string
                    userDomain = obj.["Domain"] :?> string
                })
                |> Seq.toList
