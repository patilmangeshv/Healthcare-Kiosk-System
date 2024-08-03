export class User {
    constructor(public username: string, public deskId: number, public deskCode: string, public boxId: number
        , public boxNo: string, public token: string) { }
    // constructor(public username: string, private _token: string) { }

    // get token() {
    //     return this._token;
    // }
}