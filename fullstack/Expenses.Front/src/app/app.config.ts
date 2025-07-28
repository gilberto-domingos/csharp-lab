import {
  ApplicationConfig,
  importProvidersFrom,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';

import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';

providers: [importProvidersFrom()];

import { provideHttpClient, withFetch } from '@angular/common/http';

provideHttpClient(withFetch()); // ✅ usar com fetch

import {
  provideClientHydration,
  withEventReplay,
} from '@angular/platform-browser';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(withEventReplay()),
    provideAnimations(),

    importProvidersFrom(),
    provideHttpClient(withFetch()),
  ],
};
