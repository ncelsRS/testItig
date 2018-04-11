import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { ExtLayoutHomeComponent } from './ext-layout-pages/ext-layout-home/ext-layout-home.component';
import { ExtLayoutComponent } from './ext-layout/ext-layout.component';

export const routes: Routes = [
    {
        path: '',
        data: {
            title: 'home'
        },
        component: ExtLayoutComponent,
        children: [
            {
                path: '',
                component: ExtLayoutHomeComponent
            },
            {
                path: 'contracts',
                data: { title: 'contracts' },
                loadChildren: './ext-contract/ext-contract.module#ExtContractModule'
            },
            {
                path: 'declarations',
                data: { title: 'declarations' },
                loadChildren: './ext-declaration/ext-declaration.module#ExtDeclarationModule'
            }
        ]
    }
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
