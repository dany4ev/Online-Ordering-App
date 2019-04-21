import { Component, OnInit } from '@angular/core';
import { Product } from '../Products';
import { Order } from '../Order';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  
  products: Product[] = this.productsService.getAllProducts();
  orderedItems: Order[] = this.productsService.orderedItems;
  
  constructor(private productsService: ProductsService) {
  }

  ngOnInit() {
  }

  addtocart(product: Product) {
    debugger;
    this.productsService.saveProductToInMemoryCart(product);
  }
}
