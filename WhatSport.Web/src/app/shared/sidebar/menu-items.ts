import { RouteInfo } from './sidebar.metadata';

export const ROUTES: RouteInfo[] = [
 
  {
    path: '/city',
    title: 'City',
    icon: 'bi bi-speedometer2',
    class: '',
    extralink: false,
    submenu: [],
    role: ['admin']
  },
  {
    path: '/contry',
    title: 'Country',
    icon: 'bi bi-speedometer2',
    class: '',
    extralink: false,
    submenu: [],
    role: ['admin']
  },
  {
    path: '/club/',
    title: 'Club',
    icon: 'bi bi-bell',
    class: '',
    extralink: false,
    submenu: [],
    role: ['admin','user']
  },
  {
    path: '/match/',
    title: 'Matche',
    icon: 'bi bi-patch-check',
    class: '',
    extralink: false,
    submenu: [],
    role: ['admin','user']
  },
  {
    path: '/friend',
    title: 'Friend',
    icon: 'bi bi-people',
    class: '',
    extralink: false,
    submenu: [],
    role: ['admin','user']
  }
];
