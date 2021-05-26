// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Configurator } from 'src/Configurator';
import { QueryErrorControlProps } from './QueryErrorControlProps';

/**
 * Элемент управления "Ошибка запроса".
 */
export function QueryErrorControl({
  queryCode,
  messages
}: QueryErrorControlProps) {
  const { t: functionToTranslate } = useTranslation(
    'Layer6/Controls/Errors/Query/QueryErrorControl'
  );

  const resource = Configurator.Layer6.Controls.Errors.Query.getModule().createResource(
    functionToTranslate
  );

  return messages && messages.length > 0 ? (
    <>
      <h3>{resource.getTitle(queryCode)}</h3>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </>
  ) : null;
}
