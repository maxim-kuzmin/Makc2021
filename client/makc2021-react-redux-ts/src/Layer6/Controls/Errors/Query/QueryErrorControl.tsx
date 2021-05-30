// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext } from 'react';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { QueryErrorControlProps } from './QueryErrorControlProps';

/**
 * Элемент управления "Ошибка запроса".
 */
export function QueryErrorControl({
  queryCode,
  messages
}: QueryErrorControlProps) {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Controls.Errors.Query.getModule().createResource,
    'Layer6/Controls/Errors/Query/QueryErrorControl'
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
