import { Injectable, OnInit } from '@angular/core';
import { Product } from './Products';
import { Order } from "./Order";
import { UtilitiesService } from './utilities.service';
import { environment } from 'src/environments/environment';
import productsList from '../assets/products.json';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductsService implements OnInit {

  products: any = [];
  orderedItems: Order[] = [];

  constructor(private utilitiesService: UtilitiesService, private router: Router) {
    this.products = productsList.products;
  }

  ngOnInit() {

  }

  apiUrl: string = environment.apiBaseUrl;


  public checkoutAndSaveOrder() {

    const data = JSON.stringify(this.orderedItems);
    // const otherParam: RequestInit = {
    //   headers: {
    //     "content-type": "application/json; charset=UTF-8"
    //   },
    //   body: data,
    //   method: "POST"
    // };
    log(data);
    alert('Saved your order!');
    // used to make http requests
    // fetch(this.apiUrl, otherParam)
    //   .then(data => { return data.json() })
    //   .then(res => log(res))
    //   .catch(error => log(error));
  }

  public getAllProducts() {
    // const otherParam: RequestInit = {
    //   headers: {
    //     "content-type": "application/json; charset=UTF-8"
    //   },
    //   method: "GET"
    // };

    // fetch(this.apiUrl, otherParam)
    // .then(data => { this.products = data.json() })
    // .then(res => log(res))
    // .catch(error => log(error));

    return this.products;
  }

  public saveProductToInMemoryCart(product: Product) {
    const isCartEmpty: boolean = !this.orderedItems && this.orderedItems.length === 0;
    if (isCartEmpty) return;

    let isProductInCart: boolean = this.validateExistingProductsInCart(product);
    if (isProductInCart) return;

    this.addProductToCart(product);
  }

  private addProductToCart(product: Product) {
    let order: Order = new Order();
    order.id = this.utilitiesService.generateRandomNumber(this.products.length, 1);
    order.products = [];
    order.products.push(product);
    this.orderedItems.forEach(cartItem => {
      order.totalAmount = this.utilitiesService.getTotal(cartItem.products, product);
    });
    this.orderedItems.push(order);
    this.router.navigateByUrl('/products');
  }

  private validateExistingProductsInCart(product: Product) {
    let isProductInCart: boolean = false;
    this.orderedItems.forEach(order => {
      isProductInCart = order.products.some(cartProduct => cartProduct.id === product.id);
    });
    return isProductInCart;
  }
}

function log(valueToLog: string) {
  console.log(valueToLog);
}