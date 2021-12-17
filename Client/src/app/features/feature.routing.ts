import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleComponent } from './article/article.component';
import { CustomerComponent } from './customer/customer.component';

const routes: Routes = [
  { component: CustomerComponent, path: 'customer' },
  { component: ArticleComponent, path: 'article' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class FeatureRoutingModule {}
