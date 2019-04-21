import { Category } from './Category';

export interface Product {
  id: number;
  name: string;
  description: string;
  quantity: number;
  price: number;
  imageUrl: string;
  category: Category;
}


