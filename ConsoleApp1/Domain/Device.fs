namespace ConsoleApp.Domain

module Device =
    type DeviceInfo = {
        modelName: string
        userName: string
        systemType: string
     }

     type IDeviceRepository =
        abstract member GetDevice : unit -> DeviceInfo list 
