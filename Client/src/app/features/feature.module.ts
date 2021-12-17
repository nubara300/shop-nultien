import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { FeatureRoutingModule } from './feature.routing';
import { CustomerComponent } from './customer/customer.component';
import { ArticleComponent } from './article/article.component';

@NgModule({
    declarations: [CustomerComponent, ArticleComponent],
    imports: [SharedModule, FeatureRoutingModule],
    exports: [],
    providers: [],
})
export class FeatureModule { }