export class Navigation {
    routerLink: string = "";
    name: string = "";
    icon: string = "";
}

export const Navigations: Navigation[] = [
    {
        routerLink: "/",
        name:"Ana Sayfa",
        icon:"fa fa-home "
    },
    {
        routerLink: "/ucafs",
        name:"Hesap Planı",
        icon:"fa fa-file-signature "
    },
    {
        routerLink: "/reports",
        name: "Raporlar",
        icon:"fa fa-chart-pie"
    },
    {
        routerLink: "/logs",
        name: "Log Kayıtları",
        icon: "fa fa-chalkboard-user"        
    }    
]