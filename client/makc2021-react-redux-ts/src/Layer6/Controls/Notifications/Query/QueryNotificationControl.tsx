// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext } from 'react';
import { useSelector } from 'react-redux';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { QueryNotificationItemControl } from './Item/QueryNotificationItemControl';

/**
 * Элемент управления "Извещение запроса".
 */
export function QueryNotificationControl() {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Controls.Notification.Query.getModule().createResource,
    'Layer6/Controls/Notifications/Query/QueryNotificationControl'
  );

  const store = contextValue.Layer5.Controls.Notifications.Query.getModule()
    .store;

  const queryResults = useSelector(store.selectQueryResults);

  return (
    <>
      {queryResults.map((queryResult) => {
        const {
          errorMessages,
          queryCode,
          warningMessages,
          successMessages
        } = queryResult;

        return (
          <div key={queryCode}>
            <QueryNotificationItemControl
              messages={errorMessages}
              title={resource.getTitleOfError(queryCode)}
              variant="danger"
            />
            <QueryNotificationItemControl
              messages={warningMessages}
              title={resource.getTitleOfWarning(queryCode)}
              variant="warning"
            />
            <QueryNotificationItemControl
              messages={successMessages}
              title={resource.getTitleOfSuccess(queryCode)}
              variant="success"
            />
          </div>
        );
      })}
    </>
  );
}
