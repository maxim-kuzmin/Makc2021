// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { PropsWithChildren, useContext } from 'react';
import { Nav } from 'react-bootstrap';
import { useSelector } from 'react-redux';
import { LinkContainer } from 'react-router-bootstrap';
import { Context } from 'src/Context';
import { TopMenuItemControlProps } from '../TopMenuItemControlProps';

/**
 * Элемент управления "Ссылка пункта верхнего меню".
 */
export function TopMenuItemLinkControl({
  iconClassName,
  menuItem
}: PropsWithChildren<TopMenuItemControlProps>) {
  const contextValue = useContext(Context);

  const store = contextValue.Layer5.Controls.Menus.Top.getModule().store;

  const currentItemKey = useSelector(store.selectCurrentItemKey);

  const target = menuItem.isOpenInNewTab ? '_blank' : '_self';

  const isActive = menuItem.key === currentItemKey;

  const isExternal = isActive || menuItem.isPathExternal;

  let className = 'nav-link';

  if (isActive) {
    className += ' active';
  }

  return (
    <>
      {iconClassName && <i className={iconClassName}></i>}
      {isExternal && (
        <a href={menuItem.path} target={target} className={className}>
          {menuItem.text}
        </a>
      )}
      {!isExternal && (
        <LinkContainer to={menuItem.path}>
          <Nav.Link target={target}>{menuItem.text}</Nav.Link>
        </LinkContainer>
      )}
    </>
  );
}
