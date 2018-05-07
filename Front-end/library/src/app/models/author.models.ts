export class Author {
    public id: string;
    public firstName: string;
    public lastName: string;
    public birthDate: Date;
    public deathDate: Date;
    public fullName: string;
    public books: Array<object>;
}