// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { QueryErrorControlModule } from './QueryErrorControlModule';
import { QueryErrorControlResource } from './QueryErrorControlResource';

/**
 * Использовать элемент управления "Ошибка запроса" слоя "Layer6".
 */
export function useLayer6QueryErrorControl(
  module: QueryErrorControlModule,
  moduleOfLayer1: Layer1Module
) {
  useLayer6QueryErrorControlResource(
    module,
    moduleOfLayer1,
    (localizationService: LocalizationService) => {
      return new QueryErrorControlResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс элемента управления "Ошибка запроса" слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6QueryErrorControlResource(
  module: QueryErrorControlModule,
  moduleOfLayer1: Layer1Module,
  getter?: (
    localizationService: LocalizationService
  ) => QueryErrorControlResource
) {
  const { t } = useTranslation(
    'Layer6/Controls/Errors/Query/QueryErrorControl'
  );

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(moduleOfLayer1.createLocalizationService(t));
}
