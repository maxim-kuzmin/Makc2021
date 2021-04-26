// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainListPageModule } from './DummyMainListPageModule';
import { DummyMainListPageResource } from './DummyMainListPageResource';

/**
 * Использовать страницу контактов слоя "Layer6".
 */
export function useLayer6DummyMainListPage() {
  useLayer6DummyMainListPageResource(
    (localizationService: LocalizationService) => {
      return new DummyMainListPageResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс страницы контактов слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6DummyMainListPageResource(
  getter?: (
    localizationService: LocalizationService
  ) => DummyMainListPageResource
) {
  const { t } = useTranslation('Layer6/Pages/DummyMain/List/DummyMainListPage');

  const module = DummyMainListPageModule.get();

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(Layer1Module.get().createLocalizationService(t));
}
