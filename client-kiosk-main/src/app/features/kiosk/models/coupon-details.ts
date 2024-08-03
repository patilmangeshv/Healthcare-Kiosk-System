export class CouponDetail {
    public id: number = 0;
    public floor: string = "";
    public zone: string = "";
    public deskCode: string = "";
    public serviceCode: string = "";
    public subServiceCode: string = "";
    public couponNo: number = 0;
    public couponGenerationDateTime?: Date;
    public couponNoFormatted: string = "";
    public boxNo?: string;
}