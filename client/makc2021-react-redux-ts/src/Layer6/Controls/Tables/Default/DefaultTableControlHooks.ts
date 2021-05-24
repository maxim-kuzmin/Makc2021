// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { DefaultTableControlModule } from './DefaultTableControlModule';
import { DefaultTableControlResource } from './DefaultTableControlResource';

/**
 * Использовать элемент управления "Таблица по умолчанию" слоя "Layer6".
 */
export function useLayer6DefaultTableControl(
  module: DefaultTableControlModule,
  moduleOfLayer1: Layer1Module
) {
  useLayer6DefaultTableControlResource(
    module,
    moduleOfLayer1,
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
  module: DefaultTableControlModule,
  moduleOfLayer1: Layer1Module,
  getter?: (
    localizationService: LocalizationService
  ) => DefaultTableControlResource
) {
  const { t } = useTranslation(
    'Layer6/Controls/Tables/Default/DefaultTableControl'
  );

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(moduleOfLayer1.createLocalizationService(t));
}
