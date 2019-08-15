export class JournalModel
{
    constructor()
    {
    }
    //日志标识
    journalID:string;
    //日志链接，后期考虑使用路由
    href:Array<string>;
    //日志标题
    title:string;
    //日志内容
    content:string;
    //日志记录时间
    datetime:Date;
    //作者
    author:string;
}