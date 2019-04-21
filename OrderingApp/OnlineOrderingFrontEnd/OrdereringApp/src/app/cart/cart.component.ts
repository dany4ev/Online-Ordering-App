import { Component, OnInit, Input } from '@angular/core';
import { ProductsService } from '../products.service';
import { Order } from '../Order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  @Input() orderedItems: Order[];
  
  constructor(private productsService: ProductsService) { }

  ngOnInit() {
  }

  checkout() {
    let saveOrder: boolean = confirm("Save your order ?");
    if (!saveOrder) return;

    this.productsService.checkoutAndSaveOrder();
  }
}
