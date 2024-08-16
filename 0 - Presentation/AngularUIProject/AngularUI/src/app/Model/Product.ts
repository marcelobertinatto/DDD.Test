import { Guid } from "guid-typescript";

export class Product {
    Id: Guid;
    Name: string;
    Description: string;
    Price: number;
    Qty: number;

    constructor(Id: Guid, Name: string, Description: string, Price: number, Qty: number) {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Price = Price;
        this.Qty = Qty;
    }
}
