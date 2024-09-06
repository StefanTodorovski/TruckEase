// type Nullable<T> = T | null;
export interface IPhotos {
    albumId: number;
    // id: Nullable<number>;
    id: number;
    title: string;
    url: string;
    thumbnailUrl: string;
  }
  