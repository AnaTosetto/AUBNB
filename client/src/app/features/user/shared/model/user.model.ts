export class User {
    public id?: number;
    public name: string;
    public email: string;
    public telephoneNumber: string;
    public password: string;
}

export class UserUpdate {
    public id: number;
    public name: string;
    public email: string;
    public telephoneNumber: string;
    public password: string;
}

export class LoginCommand {
    public id: number;
    public email: string;
    public password: string;
}
