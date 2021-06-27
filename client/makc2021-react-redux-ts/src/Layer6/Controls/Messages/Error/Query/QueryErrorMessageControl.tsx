// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext } from 'react';
import { Alert } from 'react-bootstrap';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { QueryErrorMessageControlProps } from './QueryErrorMessageControlProps';

/**
 * Элемент управления "Сообщение об ошибке запроса".
 */
export function QueryErrorMessageControl({
  queryCode,
  messages
}: QueryErrorMessageControlProps) {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Controls.Messages.Error.Query.getModule()
      .createResource,
    'Layer6/Controls/Messages/Error/Query/QueryErrorMessageControl'
  );

  return messages && messages.length > 0 ? (
    //<Alert variant="danger" dismissible onClose={onClose}>
    <Alert variant="danger">
      <Alert.Heading>{resource.getTitle(queryCode)}</Alert.Heading>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </Alert>
  ) : null;
}
