import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { FeatureRoutingModule } from './feature.routing';

@NgModule({
    declarations: [],
    imports: [SharedModule, FeatureRoutingModule],
    exports: [],
    providers: [],
})
export class FeatureModule { }