export class BoxServiceIPTV {
    constructor(public id: number, public boxId: number, public boxNo: string
        , public serviceId: number, public serviceName: string, public subServiceId: number
        , public deskId: number, public deskCode: string, public currentCoupon: number, public totalCoupons: number) { }
}