// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DummyMainItemPageModule } from './DummyMainItemPageModule';
import { DummyMainItemPageResource } from './DummyMainItemPageResource';

/**
 * Использовать страницу контактов слоя "Layer6".
 */
export function useLayer6DummyMainItemPage() {
  useLayer6DummyMainItemPageResource(
    (localizationService: LocalizationService) => {
      return new DummyMainItemPageResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс страницы контактов слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6DummyMainItemPageResource(
  getter?: (
    localizationService: LocalizationService
  ) => DummyMainItemPageResource
) {
  const { t } = useTranslation('Layer6/Pages/DummyMain/Item/DummyMainItemPage');

  const module = DummyMainItemPageModule.get();

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(Layer1Module.get().createLocalizationService(t));
}
