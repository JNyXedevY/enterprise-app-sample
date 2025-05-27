namespace ConsoleApp.Application.Ports

module User =
    type IUserService =
        abstract member GetUserInfo : unit -> unit 