import { Product } from './Products';
export class Order {
  id: number;
  products: Product[];
  totalAmount: number;
}
