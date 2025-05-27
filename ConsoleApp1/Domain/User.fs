namespace ConsoleApp.Domain

module User =
    type UserInfo = {
        userName:  string
        userDomain: string
    }

    type IUserRepository =
        abstract member GetUser : unit -> UserInfo list
