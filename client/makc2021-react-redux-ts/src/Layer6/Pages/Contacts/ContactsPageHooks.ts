// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { ContactsPageModule } from './ContactsPageModule';
import { ContactsPageResource } from './ContactsPageResource';

/**
 * Использовать страницу контактов слоя "Layer6".
 */
export function useLayer6ContactsPage(
  module: ContactsPageModule,
  moduleOfLayer1: Layer1Module
) {
  useLayer6ContactsPageResource(
    module,
    moduleOfLayer1,
    (localizationService: LocalizationService) => {
      return new ContactsPageResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс страницы контактов слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6ContactsPageResource(
  module: ContactsPageModule,
  moduleOfLayer1: Layer1Module,
  getter?: (localizationService: LocalizationService) => ContactsPageResource
) {
  const { t } = useTranslation('Layer6/Pages/Contacts/ContactsPage');

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(moduleOfLayer1.createLocalizationService(t));
}
