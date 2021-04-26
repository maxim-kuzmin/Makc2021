// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DefaultTableControlModule } from './DefaultTableControlModule';
import { DefaultTableControlResource } from './DefaultTableControlResource';

/**
 * Использовать элемент управления "Таблица по умолчанию" слоя "Layer6".
 */
export function useLayer6DefaultTableControl() {
  useLayer6DefaultTableControlResource(
    (localizationService: LocalizationService) => {
      return new DefaultTableControlResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс элемента управления "Таблица по умолчанию" слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6DefaultTableControlResource(
  getter?: (
    localizationService: LocalizationService
  ) => DefaultTableControlResource
) {
  const { t } = useTranslation(
    'Layer6/Controls/Tables/Default/DefaultTableControl'
  );

  const module = DefaultTableControlModule.get();

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(Layer1Module.get().createLocalizationService(t));
}
