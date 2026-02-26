export interface IUser {
  id: string;
  name: string;
}

export interface IVote {
  id: string;
  cardId: string;
  roomId: string;
  discussionId: string;
  user: IUser;
  card: ICard;
}

export interface ICard {
  id: string;
  name: string;
  value: string;
}

export interface IDiscussion {
  id: string;
  roomId: string;
  topic: string;
  dateStart: string;
  dateEnd: string;
  votes: Array<IVote>;
  averageResult: number;
  duration: number /*TODO: поменять вывод длительности обсуждения на бэке*/;
}

export interface IRoom {
  id: string;
  name: string;
  ownerId: string;
  hostId: string;
  members: Array<IUser>;
  discussions: Array<IDiscussion>;
  hashCode: string;
  deck: IDeck;
}

export interface IDeck {
  id: string;
  name: string;
  cards: Array<ICard>;
}

export interface IError {
  message: string;
}

export interface IRootState {
  room: IRoom | null;
  user: IUser | null;
  loadingIndicator: boolean;
  error: IError | null;
}
