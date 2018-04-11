import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExtDeclarationRoutingModule } from './ext-declaration-routing.module';
import { ExtDeclarationsComponent } from './ext-declarations/ext-declarations.component';
import { ExtDeclarationComponent } from './ext-declaration/ext-declaration.component';
import { ExtGeneralInformationComponent } from './ext-declaration/ext-general-information/ext-general-information.component';
import { ExtImnSetComponent } from './ext-declaration/ext-imn-set/ext-imn-set.component';
import { FormsModule } from '@angular/forms';
import { ExtProducerComponent } from './ext-declaration/ext-producer/ext-producer.component';
import { ExtAgreementComponent } from './ext-declaration/ext-agreement/ext-agreement.component';
import { TestComponent } from './ext-declaration/test/test.component';

@NgModule({
    imports: [
        CommonModule,
        ExtDeclarationRoutingModule,
        FormsModule
    ],
    declarations: [
        ExtDeclarationsComponent,
        ExtDeclarationComponent,
        ExtGeneralInformationComponent,
        ExtImnSetComponent,
        ExtProducerComponent,
        ExtAgreementComponent,
        TestComponent]
})
export class ExtDeclarationModule {
}
