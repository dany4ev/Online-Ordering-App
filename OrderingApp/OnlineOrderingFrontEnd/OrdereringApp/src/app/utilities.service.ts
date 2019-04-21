import { Injectable } from '@angular/core';
import { Order } from "./Order";
import { Product } from './Products';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {

  constructor() { }

  public generateRandomNumber (rangeFrom: number, tillRange: number) {
    return rangeFrom <= 0 ? Math.floor(Math.random() * tillRange) + rangeFrom : rangeFrom;
  }

  public getTotal(listToSum: any, product: Product) {
    let sum = 0.0;

    listToSum.forEach((product) => {
      sum = product.price + product.price;
    });

    return sum;
  }
}
